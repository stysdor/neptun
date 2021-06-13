import { Showing } from "./showing";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: Showing[];
}
