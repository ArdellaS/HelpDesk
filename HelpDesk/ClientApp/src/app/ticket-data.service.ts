import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ticket } from './interfaces/ticket';
import { Favorite, JoinedItem } from './interfaces/favorite';

@Injectable()
export class TicketDataService {
  userID: number;
  constructor(private http: HttpClient) {
    this.userID = Math.floor(Math.random() * 1000000) + 1;
    //this.userID = 5;
    }
  getTickets() {
    let result = this.http.get<Ticket[]>('/api/ticket');
    //console.log(result);
    return result;
  }

  addNewTicket(t: Ticket) {
    console.log('submitting ticket ' + t.title);
    return this.http.post<Ticket>('/api/ticket', t);
  }


  updateTicket(t: Ticket) {
    console.log('updating ticket ' + t.title);
    return this.http.put<Ticket>('/api/ticket', t);
  }

  postFavorite(id: number) {
    let item: Favorite = {
      id: 0,
      userID: this.userID,
      ticketID: id,



    };

    return this.http.post<Favorite>('/api/favorites', item);
  }
}
