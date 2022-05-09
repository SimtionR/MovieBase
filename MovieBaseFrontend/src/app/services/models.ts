

export interface Movie{
    id:number;
    moviePhoto:string;
    name:string;
    description:string;
    duration:number;
    typeOf:string;
}
export interface Actor{
    id:number;
    firstName:string;
    lastName:string;
    photo:string;
    age:number;
}

export interface MovieDetails{
    id:number;
    movieId:number;
    genres: Genres[];
    actors: Actor[];
    metaScore:number;
    userRating:number;


}

export interface Profile{
    id:number;
    userName:string;
    profilePicture:string;
    watchList:Movie[];
    playList:Movie[];
}

export interface Genres{

}

export interface ApiResponse<T> {
    results: Array<T>;
}






