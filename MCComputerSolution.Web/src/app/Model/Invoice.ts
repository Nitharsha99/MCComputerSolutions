import { Product } from "./Product";

export interface Invoice {
    customerName: string;
    transactionDate: Date;
    products: Product[];
    discount: number;
    totalAmount: number;
  }