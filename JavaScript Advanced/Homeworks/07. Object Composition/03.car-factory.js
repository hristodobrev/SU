function carFactory(carParameters) {
    let engines = {
        small: {power: 90, volume:1800},
        normal: {power: 120, volume:2400},
        monster: {power: 200, volume:3500}
    };

    let car = {
        model: carParameters.model
    };

    if (carParameters.power <= 90) {
        car.engine = engines.small;
    } else if (carParameters.power <= 120) {
        car.engine = engines.normal;
    } else {
        car.engine = engines.monster;
    }

    car.carriage = {
        type: carParameters.carriage,
        color: carParameters.color
    };

    let diameter = carParameters.wheelsize;
    if (carParameters.wheelsize % 2 == 0) {
        diameter--;
    }
    car.wheels = [diameter,diameter,diameter,diameter];

    return car;
}