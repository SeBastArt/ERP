import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { BaseFormComponent } from './../../base.form.component';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Item } from '../item';
import { ItemService } from '../item.service';
import { ApiResult } from '../../base.service';

@Component({
  selector: 'app-item-edit',
  templateUrl: './item-edit.component.html',
  styleUrls: ['./item-edit.component.css']
})
export class ItemEditComponent extends BaseFormComponent {

  //titel with Item-Name
  title: string;

  //the form model
  //form: FormGroup;

  //the item object to edit or create
  item: Item;

  // the item object id, as fetched from the active route:
  // It's NULL when we're adding a new item,
  // and not NULL when we're editing an existing one.
  id?: number;

  constructor(
    private ActivatedRoute: ActivatedRoute,
    private router: Router,
    private itemService: ItemService) 
  {
    super();
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      lat: new FormControl('', [Validators.required, Validators.pattern('^[-]?[0-9]+(\.[0-9]{1,4})?$')]),
      lon: new FormControl('', [Validators.required, Validators.pattern('^[-]?[0-9]+(\.[0-9]{1,4})?$')]),
      countryId: new FormControl('', Validators.required)
    }, null, null);
    this.loadData();
  }

  loadData() {
    //retrieve the id from the 'id' parameter
    this.id = +this.ActivatedRoute.snapshot.paramMap.get('id');

    if (this.id) {
      //EditMode

      //fetch the item from the server
      this.itemService.get<Item>(this.id).subscribe(result => {
        this.item = result;
        this.title = "Edit - " + this.item.name;

        // update the form with the item value
        this.form.patchValue(this.item);
      }, error => console.error(error));
    } else {
      //Add new mode
      this.title = "Create a new item";
    }
  }

  onSubmit() {
    const item = (this.id) ? this.item : {} as Item;

    item.name = this.form.get("name").value;
    item.labelName = this.form.get("labelName").value;
    item.availableStock = +this.form.get("availableStock").value;

    if (this.id) {
      //edit mode
      this.itemService.put<Item>(item).subscribe(result => {
        console.log("Item " + item.id + " has been updated");

        //go back to itemies view
        this.router.navigate(['/cities']);
      }, error => console.error(error));
    } else {
      //Add new mode
      this.itemService.post<Item>(item).subscribe(result => {
        console.log("Item " + item.id + " has been created");

        //go back to itemies view
        this.router.navigate(['/cities']);
      }, error => console.error(error));
    }
  }
}
