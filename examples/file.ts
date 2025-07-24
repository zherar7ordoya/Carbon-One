enum UserRole {
    Admin,
    Guest,
    User
}

interface IUser {
    name: string;
    role: UserRole;
    login(): void;
}

type UserData = Readonly<{
    id: number;
    email: string;
}>;

class BaseUser implements IUser {
    constructor(public name: string, public role: UserRole) {}

    login(): void {
        console.log(`${this.name} has logged in as ${UserRole[this.role]}`);
    }
}

class AdminUser extends BaseUser {
    constructor(name: string) {
        super(name, UserRole.Admin);
    }

    accessAdminPanel(): void {
        console.log(`${this.name} accessing admin panel...`);
    }
}

type OperationResult<T> = {
    success: boolean;
    result: T;
};

class Processor<T> {
    process(task: () => T): OperationResult<T> {
        try {
            const result = task();
            return { success: true, result };
        } catch {
            return { success: false, result: undefined as any };
        }
    }
}

type UserCallback = (user: IUser) => void;

function main(): void {
    const user: IUser = new AdminUser("Alice");
    user.login();

    const processor = new Processor<number>();
    const result = processor.process(() => 42);
    console.log(`Success: ${result.success}, Value: ${result.result}`);

    const callback: UserCallback = user => {
        console.log(`Callback for ${user.name}`);
    };
    callback(user);
}

main();
