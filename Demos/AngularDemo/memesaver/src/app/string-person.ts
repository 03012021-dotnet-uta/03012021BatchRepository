import { Guid } from "guid-typescript";
import { Meme } from "./meme";

export class StringPerson {
  personId: Guid;
  fname: string;
  lname: string;
  userName: string;
  passwordHash: string;
  memberSince: Date;
  memes: Meme[];
  memesILiked: Meme[];
}
