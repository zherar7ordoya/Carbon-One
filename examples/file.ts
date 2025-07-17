import { readFileSync } from 'fs';
import { join } from 'path';

interface Appliance {
    brand: string;
    turnOn(): void;
}

class WashingMachine implements Appliance {
    
    brand: string;
    temporal: any;

    constructor(brand: string) {
        this.temporal = readFileSync(join(__dirname, 'themes', 'gray-clc-color-theme.json'), 'utf-8'); 
        this.brand = brand;
    }

    turnOn(): void {
        console.log(`${this.brand} washing machine is now on.`);
    }
}

const myWasher = new WashingMachine('LG');
myWasher.turnOn(); // LG washing machine is now on.Conclusion