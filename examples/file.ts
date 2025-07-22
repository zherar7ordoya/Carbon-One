namespace EmployeeManagementSystem {
    // Decorador personalizado
    function Auditable(description: string) {
        return function (target: any) {
            target.description = description;
        };
    }

    // Enumeración
    enum Department {
        HR,
        IT,
        Finance
    }

    // Interfaz genérica
    interface IEntity<T> {
        id: T;
        getDetails(): string;
    }

    // Clase abstracta (simulada con clase base)
    abstract class Person {
        public name: string;
        public age: number;

        constructor(name: string, age: number) {
            this.name = name;
            this.age = age;
        }

        abstract getRole(): string;
    }

    // Clase concreta con herencia
    @Auditable("Employee class for tracking")
    class Employee extends Person implements IEntity<number> {
        // Campos y propiedades
        private readonly _employeeId: number;
        public get id(): number { return this._employeeId; }
        public department: Department;
        public salary: number | null;
        public static employeeCount: number = 0;
        public readonly skills: string[] = [];

        // Constructor
        constructor(id: number, name: string, age: number, department: Department, salary: number | null) {
            super(name, age);
            this._employeeId = id;
            this.department = department;
            this.salary = salary;
            Employee.employeeCount++;
        }

        // Propiedad con valor por defecto
        public title: string = "Employee";

        // Método sobrescrito
        public getRole(): string {
            return `Employee in ${this.department}`;
        }

        // Método con expresión lambda
        public getIdDescription: (id: number) => string = id => `Employee ID: ${id}`;

        // Método genérico
        public computeBonus<T extends number | bigint>(baseBonus: T): T {
            if (this.salary !== null) {
                return baseBonus;
            }
            return <T>0;
        }

        // Método asíncrono
        public async fetchDetailsAsync(): Promise<string> {
            await new Promise(resolve => setTimeout(resolve, 100)); // Simula operación asíncrona
            return this.getDetails();
        }

        // Implementación de interfaz
        public getDetails(): string {
            return `${this.name}, ${this.age} years old, ${Department[this.department]}, Salary: ${this.salary ?? "N/A"}`;
        }

        // Método estático
        public static createDefault(): Employee {
            return new Employee(0, "Unknown", 0, Department.HR, null);
        }
    }

    // Métodos de extensión (simulados con función utilitaria)
    function getSummary(employee: Employee): string {
        return `Summary: ${employee.getDetails()}`;
    }

    // Función principal para pruebas
    async function main(): Promise<void> {
        try {
            // Variables y constantes
            const maxEmployees: number = 10;
            const employees: Employee[] = [
                new Employee(1, "Alice", 30, Department.IT, 75000.50),
                new Employee(2, "Bob", 25, Department.Finance, null)
            ];

            // Bucle for...of
            for (const emp of employees.filter(e => e.age > 20)) {
                console.log(emp.getDetails());
                console.log(getSummary(emp));
            }

            // Switch expression (simulada con objeto)
            const departmentName = ((dept: Department) => {
                switch (dept) {
                    case Department.HR: return "Human Resources";
                    case Department.IT: return "Information Technology";
                    case Department.Finance: return "Finance";
                    default: return "Unknown";
                }
            })(employees[0].department);
            console.log(`Department: ${departmentName}`);

            // Lambda y filter
            const seniorEmployees = employees.filter(e => e.age >= 30);
            console.log(`Senior employees: ${seniorEmployees.length}`);

            // Asincronía
            const details = await employees[0].fetchDetailsAsync();
            console.log(`Async details: ${details}`);

            // Operador condicional nulo
            const totalSalary = employees.reduce((sum, e) => sum + (e.salary ?? 0), 0);
            console.log(`Total salary: ${totalSalary}`);
        } catch (ex) {
            console.log(`Error: ${(ex as Error).message}`);
        }
    }

    // Ejecutar el programa
    main();
}