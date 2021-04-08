import { Guid } from "guid-typescript";
import { Meme } from "./meme";

export class StringPerson {
  PersonId: Guid;
  Fname: string;
  Lname: string;
  UserName: string;
  PasswordHash: string;
  MemberSince: Date;
  Memes: Meme[];
  MemesILiked: Meme[];
}
