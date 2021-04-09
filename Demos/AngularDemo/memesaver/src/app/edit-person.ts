import { Guid } from "guid-typescript";

export class EditPerson {
  personId: string;
  fname: string;
  lname: string;
  username: string;
  newPassword: string;
  passwordHash: string;
  newUsername: string;
}
