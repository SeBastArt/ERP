export interface PagedItemResult {
  totalCount: number;
  pageIndex: number;
  pageSize: number;
  data: Item[];
}

export interface Item {

  id: string;
  name: string;
  labelName: string;
  availableStock: number;
}
