










const CONSTANT_VALUE = 100;

//******************************************************************************

// An exceptionally useful comment
function func(param) {
    var text = 'string';
    for (var i = 0; i < param.length; i++) {
        text += i;
    }
    return {
        "text": text,
        "boolean": false
    };
}

//******************************************************************************

interface IColorizable { }

enum ColorEnum {
    Red,
    Green,
    Blue
}

type ColorType = string | number;

class BaseClass { }

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
