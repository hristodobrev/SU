function tickets(ticketsArr, orderCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];
    for (let ticketStr of ticketsArr) {
        let [destination, price, status] = ticketStr.split('|');
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    switch (orderCriteria) {
        case 'destination':
            tickets.sort((a, b) => a.destination > b.destination);
            break;
        case 'price':
            tickets.sort((a, b) => Number(a.price) > Number(b.price));
            break;
        case 'status':
            tickets.sort((a, b) => a.status > b.status);
            break;
    }

    return tickets;
}

let ticketsArr = tickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination');
for (let ticket of ticketsArr) {
    console.log(ticket);
}