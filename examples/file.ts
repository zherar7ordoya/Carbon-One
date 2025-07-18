// Este es un comentario de documentación
/**
 * Representa una interfaz genérica con eventos y decoradores
 */
@LogClass
export class Rocket<TPayload extends PayloadBase> extends BaseRocket implements Launchable {
    private static readonly MAX_ALTITUDE = 100000; // constante
    readonly id: string;
    private fuelLevel: number = 100;
    private payload: TPayload;

    constructor(id: string, payload: TPayload) {
        super();
        this.id = id;
        this.payload = payload;
    }

    @MeasurePerformance()
    launch(@Inject('engine') engine: Engine, speed: number): boolean {
        if (!engine) throw new Error("Engine required");

        console.log(`Launching rocket ${this.id} at ${speed} km/h`);
        engine.ignite();
        return true;
    }

    abort(): void {
        console.warn("Launch aborted!");
    }

    get currentPayload(): TPayload {
        return this.payload;
    }

    set currentPayload(value: TPayload) {
        this.payload = value;
    }

    static fromJSON(json: string): Rocket<TPayload> {
        const data = JSON.parse(json);
        return new Rocket(data.id, data.payload);
    }

    private logFuel(): void {
        console.log(`Fuel level: ${this.fuelLevel}%`);
    }
}

// Namespace con funciones y tipos
namespace RocketUtils {
    export type RocketID = string;

    export function generateID(): RocketID {
        return `ROCKET-${Math.floor(Math.random() * 1000)}`;
    }

    export const STATUS = {
        READY: "ready",
        LAUNCHED: "launched",
        FAILED: "failed"
    } as const;
}

// Enums
export enum RocketStatus {
    Idle,
    Launching,
    InOrbit,
    Returning,
    Destroyed
}

// Interfaces y tipos auxiliares
interface PayloadBase {
    weight: number;
    type: string;
}

interface Launchable {
    launch(engine: Engine, speed: number): boolean;
}

interface Engine {
    ignite(): void;
}

// Decorators
function LogClass<T extends { new(...args: any[]): {} }>(constructor: T) {
    return class extends constructor {
        createdAt = new Date();
    };
}

function MeasurePerformance() {
    return function (target: any, propertyKey: string, descriptor: PropertyDescriptor) {
        const original = descriptor.value;
        descriptor.value = function (...args: any[]) {
            const start = performance.now();
            const result = original.apply(this, args);
            const end = performance.now();
            console.log(`${propertyKey} took ${end - start}ms`);
            return result;
        };
    };
}

function Inject(serviceName: string) {
    return function (target: any, propertyKey: string | symbol, parameterIndex: number) {
        console.log(`Injecting ${serviceName} into parameter #${parameterIndex} of ${String(propertyKey)}`);
    };
}
