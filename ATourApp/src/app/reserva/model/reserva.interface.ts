export interface Reserva {
    hotelId: number;
    clienteId: number;
    startDay: Date;
    endDay: Date;
    countRoon: number;
}

export class InitializeR {
    public static reserva: Reserva = {
        hotelId: 0,
        clienteId: 0,
        startDay: new Date,
        endDay: new Date,
        countRoon:0
    }
}