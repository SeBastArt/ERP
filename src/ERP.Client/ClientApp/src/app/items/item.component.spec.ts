import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { AngularMaterialModule } from '../angular-material.module';
import { of } from 'rxjs';

import { ItemsComponent } from './items.component';
import { Item } from './item';
import { ItemService } from './item.service';
import { ApiResult } from '../base.service';

describe('ItemsComponent', () => {
  let fixture: ComponentFixture<ItemsComponent>;
  let component: ItemsComponent;

  // async beforeEach(): TestBed initialization
  beforeEach(async(() => {

    // Create a mock itemService object with a mock 'getData' method
    let itemService = jasmine.createSpyObj<ItemService>(
      'ItemService', ['getData']
    );
    // Configure the 'getData' spy method
    itemService.getData.and.returnValue(
      // return an Observable with some test data
      of<ApiResult<Item>>(<ApiResult<Item>>{
        data: [
          <Item>{
            name: 'TestItem1',
            labelName: 'label1', availableStock: 1
          },
          <Item>{
            name: 'TestItem2',
            labelName: 'label3', availableStock: 1
          },
          <Item>{
            name: 'TestItem3',
            labelName: 'label4', availableStock: 1
          }
        ],
        totalCount: 3,
        pageIndex: 0,
        pageSize: 10
      }));

    TestBed.configureTestingModule({
      declarations: [ItemsComponent],
      imports: [
        BrowserAnimationsModule,
        AngularMaterialModule,
        RouterTestingModule
      ],
      providers: [
        {
          provide: ItemService,
          useValue: itemService
        }
      ]
    })
      .compileComponents();
  }));

  // synchronous beforeEach(): fixtures and components setup
  beforeEach(() => {
    fixture = TestBed.createComponent(ItemsComponent);
    component = fixture.componentInstance;

    component.paginator = jasmine.createSpyObj(
      "MatPaginator", ["length", "pageIndex", "pageSize"]
    );

    fixture.detectChanges();
  });

  it('should display a "Items" title', async(() => {
    let title = fixture.nativeElement
      .querySelector('h1');
    expect(title.textContent).toEqual('Items');
  }));

  it('should contain a table with a list of one or more items', async(() => {
    let table = fixture.nativeElement
      .querySelector('table.mat-table');
    let tableRows = table
      .querySelectorAll('tr.mat-row');
    expect(tableRows.length).toBeGreaterThan(0);
  }));
});
