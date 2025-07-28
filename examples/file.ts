










// test-textmate.ts
// 🚀 Explorando al máximo TextMate con TypeScript

// ==== 1. Decoradores y Mixins ====
function Log(target: any, key: string, descriptor: PropertyDescriptor) {
  const original = descriptor.value;
  descriptor.value = function (...args: any[]) {
    console.log(`📝 Llamada a ${key} con`, args);
    return original.apply(this, args);
  };
}
type Constructor<T = {}> = new (...args: any[]) => T;
function Timestamped<TBase extends Constructor>(Base: TBase) {
  return class extends Base {
    timestamp = Date.now();
  };
}

// ==== 2. Namespaces y Módulos Ambientales ====
export namespace Utils {
  export function isString(x: any): x is string {
    return typeof x === "string";
  }
  export const PI = 3.1415;
}

declare module "external-lib" {
  export function externalFunc(a: number): void;
}

// ==== 3. Clases, Abstractas, Genéricas y Herencia ====
abstract class Shape {
  abstract area(): number;
}
class Rectangle extends Shape {
  constructor(public width: number, public height: number) { super(); }
  area() { return this.width * this.height; }
}
class ColoredRectangle extends Timestamped(Rectangle) {
  constructor(width: number, height: number, public color: string) {
    super(width, height);
  }
  @Log
  describe(): string {
    return `Un rectángulo ${this.color} de área ${this.area()}`;
  }
}

// ==== 4. Interfaces, Type Aliases y Conditional Types ====
interface Point { x: number; y: number; }
type ReadonlyPoint = Readonly<Point>;
type Nullable<T> = T | null | undefined;
type ExtractStrings<T> = T extends string ? T : never;
type Mapped<T> = { [K in keyof T as `get${Capitalize<string & K>}`]: () => T[K] };
type TestMapped = Mapped<{ foo: number; bar: boolean }>;

// ==== 5. Enums, Const Enums y Unique Symbols ====
enum Direction { Up, Down, Left, Right }
const enum Color { Red = "#f00", Green = "#0f0", Blue = "#00f" }
const uniqueSym: unique symbol = Symbol("myUnique");

// ==== 6. Record, Tuple, Union e Intersection ====
type StringNumberRecord = Record<"a" | "b" | "c", number>;
type PointTuple = [number, number, ...string[]];
type UnionType = { kind: "circle"; r: number } | { kind: "rect"; w: number; h: number };
type IntersectionType = { id: string } & { meta: object };

// ==== 7. Literales, Template Strings y Regex ====
const binary = 0b1010;
const hex = 0xdeadbeef;
const big = 123n;
const msg = `Valor es ${binary} y hex ${hex}`;
const regex = /^(?<year>\d{4})-(\d{2})-(\d{2})$/u;

// ==== 8. Funciones Sobrecargadas y Arrow ====
function combine(a: string, b: string): string;
function combine(a: number, b: number): number;
function combine(a: any, b: any): any {
  return a + b;
}
const arrow = <T>(x: T): T[] => [x];

// ==== 9. Assertion y Overrides (TS 4.3+) ====
class Base {
  toString(): string { return "base"; }
}
class Sub extends Base {
  override toString(): string { return "sub"; }
}
const asConst = { x: 10, y: 20 } as const;
const satisfiesExample = { a: 1, b: 2 } satisfies Record<string, number>;

// ==== 10. Comentarios y Region Folding ====
//#region Código “mágico”
function magical<T extends object>(obj: T): Readonly<T> {
  return Object.freeze({ ...obj });
}
//#endregion

// Uso de todo
const rect = new ColoredRectangle(3, 4, "azul");
console.log(rect.describe());
console.log(Utils.isString(msg), Utils.PI, combine(5, 10));
