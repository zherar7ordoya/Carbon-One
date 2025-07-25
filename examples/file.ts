const CONSTANT_VALUE = 100;

interface IColorizable {}

enum ColorEnum { Red, Green, Blue }

type ColorType = string | number;

class BaseClass {}

class DerivedClass extends BaseClass implements IColorizable {
    static supportVariable: string = "Test";

    color: ColorEnum;

    constructor(color: ColorEnum) {
        super();
        this.color = color;
    }

    public static main(): void {
        let instance: DerivedClass = new DerivedClass(ColorEnum.Green);
        console.log(typeof instance);
    }
}
