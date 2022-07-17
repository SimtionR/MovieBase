

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
    userId:string;
    userName:string;
    profilePicture:string;
    watctList:Movie[];
    playList:Movie[];
}

export interface UserReview{
    id:number;
    profileId:number;
    profile:Profile;
    title:string;
    numberOfLikes: number;
    numberOfDislikes: number;
    rewiewContent:string;
    commentDate:Date;
    rating:number;
    movieId:number;
}

export interface CriticReview{
    id:number,
    companyName: string,
    criticId: string,
    title: string,
    movieId : number,
    reviewContent: string,
    commentDate:Date,
    rating: number,
    numberOfLikes: number;
    numberOfDislikes: number;
}

export interface ConnectionPending{
    id: number;
    senderId: number;
    senderName: string;
    senderPhoto: string;
    receiverId: number;
}

export interface Connection{
    id: number,
    profileConnectionId: number,
    profileUserName: string,
    profilePicture: string
}

export interface Reaction{
    id: number;
    reviewId: number;
    profileId: number;
    profile: Profile;
    isLiked: boolean;
    isDisliked: boolean;
}

export interface ResponsePending
{
    id: number;
    pendingId: number;
    senderId: number;
    senderName: string;
    senderPhoto: string;
    receiverId: number;
    receiverName: string;
    receiverPhoto: string;
    isAccepted: boolean;
}

export interface ResponsePendingRequest
{
    pendingId: number;
    senderId: number;
    senderName: string;
    senderPhoto: string;
    receiverId: number;
    receiverName: string;
    receiverPhoto: string;
}

export class Message{
    user: string;
    text: string;
}

export interface Genres{

}

export interface ApiResponse<T> {
    results: Array<T>;
}






