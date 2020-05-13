export interface Ticket {
  ticketID: number;
  userID: number;
  title: string;
  category: string;
  ticketDetail: string;
  openedBy: string;
  ticketStatus: boolean;
  resolution: string;
  resolvedBy: string;
}
