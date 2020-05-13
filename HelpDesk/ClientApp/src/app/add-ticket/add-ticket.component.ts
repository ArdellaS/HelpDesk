import { Component, OnInit } from '@angular/core';
import { Ticket } from '../interfaces/ticket';
import { TicketDataService } from '../ticket-data.service';

@Component({
  selector: 'app-add-ticket',
  templateUrl: './add-ticket.component.html',
  styleUrls: ['./add-ticket.component.css']
})
export class AddTicketComponent implements OnInit {

  title: string;
  category: string;
  details: string;
  openedBy: string;

  constructor(private ticketData: TicketDataService) { }

  ngOnInit() {
  }


 addTicket() {
   this.ticketData.addNewTicket({
     ticketID: 0,
     userID: this.ticketData.userID,
     title: this.title,
     category: this.category,
     ticketDetail: this.details,
     openedBy: this.openedBy,
     ticketStatus: false,
     resolution: null,
     resolvedBy: null
   }).subscribe(
     (data: object) => console.log(data), error => console.error(error));
  }


}
