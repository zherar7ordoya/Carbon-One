import { Injectable } from '@angular/core';
import Note from '../../models/Note';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class NoteService {

    readonly API_URL = 'http://localhost:3000/notes'; 
    notes: Note[];

    constructor(private http: HttpClient) {
        this.notes = [];
    }

    getNotes() {
        return this.http.get<Note[]>(this.API_URL);
    }

    createId = () => {
        return Date.now().toString(36) + Math.random().toString(36).slice(2);
    };

    updateTitle(id: string, newTitle: string) {
        const note = this.notes.find((note) => note.id === id);
        if (!note) return;
        note.title = newTitle;
    }

    updateMarked(id: string) {
        const note = this.notes.find((note) => note.id === id);
        if (note) note.marked = !note.marked;
    }

    createNote(note: Note) {
        this.notes.unshift(note);
    }
}
