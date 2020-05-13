import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { TicketsComponent } from './tickets/tickets.component';
import { TicketDetailComponent } from './ticket-detail/ticket-detail.component';
import { TicketDataService } from './ticket-data.service';
import { FavoriteDataService } from './favorite-data.service';
import { AddTicketComponent } from './add-ticket/add-ticket.component';
import { EditTicketComponent } from './edit-ticket/edit-ticket.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FavoritesComponent,
    TicketDetailComponent,
    TicketsComponent,
    AddTicketComponent,
    EditTicketComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: TicketsComponent, pathMatch: 'full' },
      { path: 'tickets', component: TicketsComponent },
      { path: 'favorites', component: FavoritesComponent },
    ])
  ],
  providers: [TicketDataService, FavoriteDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
