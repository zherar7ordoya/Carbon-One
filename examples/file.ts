interface Appliance {
    brand: string;
    turnOn(): void;
}

class WashingMachine implements Appliance {
    
    brand: string;

    constructor(brand: string) {
        this.brand = brand;
    }

    turnOn(): void {
        console.log(`${this.brand} washing machine is now on.`);
    }
}

const myWasher = new WashingMachine('LG');
myWasher.turnOn(); // LG washing machine is now on.Conclusion