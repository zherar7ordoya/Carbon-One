// src/utils/types.ts
export type Medium = {
    id: string;
    nombre: string;
    web: string;
    facebook?: string;
    twitter?: string;
    instagram?: string;
    youtube?: string;
    tipo: 'dp' | 'dn';
};

export type AppState = {
    data: Medium[];
    filtered: Medium[];
    current: Medium | null;
    filterText: string;
    typeFilter: 'all' | 'dp' | 'dn';
    delimiter: string;
};