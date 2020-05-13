import { Component, Input, OnInit } from '@angular/core';
import { Ticket } from '../interfaces/ticket';
import { TicketDataService } from '../ticket-data.service';

@Component({
  selector: 'app-ticket-detail',
  templateUrl: './ticket-detail.component.html',
  styleUrls: ['./ticket-detail.component.scss']
})
/** ticket-detail component*/
export class TicketDetailComponent {

  @Input() myTicket: Ticket;


  constructor(private ticketService: TicketDataService) { }

  ngOnInit(): void {

  }
  editTicket(ticketid: number, resolution: string, resolvedby: string) {
    this.ticketService.updateTicket({
      ticketID: ticketid,
      userID: this.ticketService.userID,
      title: this.myTicket.title,
      category: this.myTicket.category,
      ticketDetail: this.myTicket.ticketDetail,
      openedBy: this.myTicket.openedBy,
      ticketStatus: true,
      resolution: resolution,
      resolvedBy: resolvedby
    }).subscribe(
      (data: object) => console.log(data), error => console.error(error));
  }
}
