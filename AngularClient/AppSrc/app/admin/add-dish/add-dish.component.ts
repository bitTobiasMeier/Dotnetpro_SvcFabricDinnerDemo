import {RestaurantAdminClient, Dish} from '../../shared/Controllers.generated';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'dinner-add-dish',
  templateUrl: './add-dish.component.html',
  styleUrls: ['./add-dish.component.sass']
})
export class AddDishComponent implements OnInit {
  @Input() restaurantId: string;
  @Output() dishAdded = new EventEmitter < Dish >();
  name: string;
  message: string;
  price: number;
  description: string;
  imageUrl: string;


  constructor(private restaurantAdminClient: RestaurantAdminClient) { }

  save (value: any) {
    if (this.name && this.price && this.price > 0 && this.imageUrl && this.description){    
    const dish = new Dish();
    dish.name = this.name;
    dish.price = this.price;
    dish.description = this.description;
    dish.imageUrl = this.imageUrl;
      this.restaurantAdminClient.addDish(this.restaurantId, dish).subscribe(
        (result) => {
            this.dishAdded.emit ( result );
            this.name = "";
            this.price = null;
            this.description = "";
            this.imageUrl = "";
            this.message= "Gericht wurde hinzugefügt";
        },
        (error) => {
            console.log(error);
        }
      );
    } else {
      this.message = "Bitte alle Felder angeben!";
    }
  }

  ngOnInit() {


  }

}
