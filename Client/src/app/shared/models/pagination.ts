import { IShowing } from "./showing";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IShowing[];
}
