import { InvoiceItem } from "./InvoiceItem";

export interface Invoice {
    invoiceId:number;
    customerName: string;
    transactionDate: Date;
    invoiceItems: InvoiceItem[];
    discount: number;
    totalAmount: number;
  }