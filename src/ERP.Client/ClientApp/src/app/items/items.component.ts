import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { Item } from './item';
import { ItemService } from './item.service';
import { ApiResult } from '../base.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name', 'labelName', 'availableStock'];
  public items: MatTableDataSource<Item>;

  defaultPageIndex = 0;
  defaultPageSize = 10;
  public defaultSortColumn = "name";
  public defaultSortOrder = "asc";

  defaultFilterColumn = "name";
  filterQuery: string = null;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private itemService: ItemService) {
  }

  ngOnInit() {
    this.loadData();
  }

  loadData(query: string = null) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;
    this.filterQuery = query;
    this.getData(pageEvent);
  }

  getData(event: PageEvent) {
    const sortColumn = (this.sort) ? this.sort.active : this.defaultSortColumn;
    const sortOrder = (this.sort) ? this.sort.direction : this.defaultSortOrder;
    const filterColumn = (this.defaultFilterColumn) ? this.defaultFilterColumn : null;
    const filterQuery = (this.filterQuery) ? this.filterQuery : null;

    this.itemService.getData<ApiResult<Item>>(
      event.pageIndex,
      event.pageSize,
      sortColumn,
      sortOrder,
      filterColumn,
      filterQuery
    ).subscribe(result => {
        this.paginator.length = result.totalCount;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        this.items = new MatTableDataSource<Item>(result.data);
      }, error => console.error(error));
  }
}5
