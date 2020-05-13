export interface Favorite {
  id: number;
  userID: number;
  ticketID: number;
}

export interface JoinedItem {
  id: number;
  userID: number;
  ticketID: number;
  title: string;
  category: string;
  ticketDetail: string;
  openedBy: string;
  ticketStatus: boolean;
  resolution: string;
  resolvedBy: string;
}
