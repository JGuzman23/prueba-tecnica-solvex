export interface Hotel {
    id:               number;
    isActive:         boolean;
    idCliente:        number;
    photos:           Photo[];
    videos:           Video[];
    name:             string;
    price:            number;
    category:         string;
    place:            string;
    titleDescription: string;
    description:      string;
    point:            number;
    minNight:         number;
    capacity:         number;
}


export interface Photo {
    id:      number;
    idHotel: number;
    name:    string;
}
export interface Video {
    id:      number;
    idHotel: number;
    name:    string;
}

export class InitializeH {
    public static Hotel :Hotel={
    id:              0,
    isActive:         false,
    idCliente:        0,
    photos:           []=[],
    videos:           []=[],
    name:            "",
    price:            0,
    category:         "",
    place:            "",
    titleDescription: "",
    description:      "",
    point:          0,
    minNight:       0,
    capacity:       0
    }
}