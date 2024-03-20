export interface GeneratedInvoice {
    customerName: string;
    discount: any;
    items: ParchasedItem[];
  }

export interface ParchasedItem{
    parchasedProductId: number;
    quantity: number;
}