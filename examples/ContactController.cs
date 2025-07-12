using Domain.Models;
using Domain.Services;

namespace Application;

public class ContactController
{
    private readonly IContactRepository _repository;
    private readonly List<Person> _persons;
    private int _position;

    public ContactController(IContactRepository repository)
    {
        _repository = repository;
        _persons = [.. _repository.LoadAll()];
        _position = _persons.Count > 0 ? 0 : -1;
    }

    public IReadOnlyList<Person> GetAll() => _persons;

    public Person? GetCurrent()
    {
        if (_position < 0 || _position >= _persons.Count)
            return null;
        return _persons[_position];
    }

    public bool MoveNext()
    {
        if (_position < _persons.Count - 1)
        {
            _position++;
            return true;
        }
        return false;
    }

    public bool MovePrevious()
    {
        if (_position > 0)
        {
            _position--;
            return true;
        }
        return false;
    }

    public void Add(string firstName, string address)
    {
        var person = new Person(firstName, address);
        _persons.Add(person);
        _position = _persons.Count - 1;
        _repository.SaveAll(_persons);
    }


    public bool DeleteCurrent()
    {
        if (_position < 0 || _position >= _persons.Count)
            return false;

        _persons.RemoveAt(_position);

        if (_position > _persons.Count - 1)
            _position = _persons.Count - 1;

        _repository.SaveAll(_persons);
        return true;
    }

    public int GetCurrentIndex() => _position;

    public int Count => _persons.Count;
}
