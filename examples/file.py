










from abc import ABC, abstractmethod
import math
import datetime


class Shape(ABC):
    created_at: datetime.datetime

    def __init__(self):
        self.created_at = datetime.datetime.now()

    @abstractmethod
    def area(self) -> float:
        pass


class Circle(Shape):
    def __init__(self, radius: float):
        super().__init__()
        self.radius = radius

    def area(self) -> float:
        return math.pi * self.radius ** 2


def print_shape_info(shape: Shape):
    print(f"{type(shape).__name__} area: {shape.area():.2f}")


if __name__ == "__main__":
    circle = Circle(3.5)
    print_shape_info(circle)
