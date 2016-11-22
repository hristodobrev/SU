function computer() {
    class Keyboard {
        constructor(manufacturer, responseTime) {
            this.manufacturer = manufacturer;
            this.responseTime = responseTime;
        }

        get manufacturer() {
            return this._manufacturer;
        }

        set manufacturer(value) {
            this._manufacturer = value;
        }

        get responseTime() {
            return this._responseTime;
        }

        set responseTime(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The response time must be a positive number');
            }

            this._responseTime = value;
        }
    }

    
    class Monitor {
        constructor(manufacturer, width, height) {
            this.manufacturer = manufacturer;
            this.width = width;
            this.height = height;
        }

        get manufacturer() {
            return this._manufacturer;
        }

        set manufacturer(value) {
            this._manufacturer = value;
        }

        get width() {
            return this._width;
        }

        set width(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The width must be a positive number');
            }

            this._width = value;
        }

        get height() {
            return this._height;
        }

        set height(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The height must be a positive number');
            }

            this._height = value;
        }
    }

    class Battery {
        constructor(manufacturer, expectedLife) {
            this.manufacturer = manufacturer;
            this.expectedLife = expectedLife;
        }

        get manufacturer() {
            return this._manufacturer;
        }

        set manufacturer(value) {
            this._manufacturer = value;
        }

        get expectedLife() {
            return this._expectedLife;
        }

        set expectedLife(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The expected life must be a positive number');
            }

            this._expectedLife = value;
        }
    }

    class Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target == Computer) {
                throw new TypeError('Cannot instantiate abstract class directly');
            }

            this.manufacturer = manufacturer;
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }

        get manufacturer() {
            return this._manufacturer;
        }

        set manufacturer(value) {
            this._manufacturer = value;
        }

        get processorSpeed() {
            return this._processorSpeed;
        }

        set processorSpeed(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The processor speed must be a positive number');
            }

            this._processorSpeed = value;
        }

        get ram() {
            return this._processorSpeed;
        }

        set ram(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The ram must be a positive number');
            }

            this._ram = value;
        }

        get hardDiskSpace() {
            return this._hardDiskSpace;
        }

        set hardDiskSpace(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The hard disk space must be a positive number');
            }

            this._hardDiskSpace = value;
        }
    }

    class Desktop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace,
                    keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() {
            return this._keyboard;
        }

        set keyboard(value) {
            if (value.constructor.name != 'Keyboard' || value < 0) {
                throw new TypeError('Keyboard must be of type keyboard');
            }

            this._keyboard = value;
        }

        get monitor() {
            return this._monitor;
        }

        set monitor(value) {
            if (value.constructor.name != 'Monitor' || value < 0) {
                throw new TypeError('Monitor must be of type monitor');
            }

            this._monitor = value;
        }
    }

    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace,
                    weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get color() {
            return this._color;
        }

        set color(value) {
            this._color = value;
        }

        get weight() {
            return this._weight;
        }

        set weight(value) {
            if (typeof value != 'number' || value < 0) {
                throw new TypeError('The processor speed must be a positive number');
            }

            this._weight = value;
        }

        get battery() {
            return this._battery;
        }

        set battery(value) {
            if (value.constructor.name != 'Battery' || value < 0) {
                throw new TypeError('Battery must be of type battery');
            }

            this._battery = value;
        }
    }

    return {
        Keyboard,
        Monitor,
        Battery,
        Computer,
        Desktop,
        Laptop
    }
}

let result = computer();

let Keyboard = result.Keyboard;
let Monitor = result.Monitor;
let Battery = result.Battery;
let Computer = result.Computer;
let Desktop = result.Desktop;
let Laptop = result.Laptop;

let battery = new Battery('Toshiba', 3);
let laptop = new Laptop('Lenovo', 3, 8, 1, 2, 'white', battery);
console.log(laptop.battery);

let keyboard = new Keyboard('A4tech', 10);
let monitor = new Monitor('Samsung', 30, 20);
let desktop = new Desktop('Coler Master', 3.80, 16, 2, keyboard, monitor);