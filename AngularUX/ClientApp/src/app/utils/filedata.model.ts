export class FileData {
  constructor(dto: any = null) {
    if (dto != null) {
      Object.assign(this, dto);
    }
  }

  uniqueId: number;
  emailAddress: string;
  firstName: string;
  lastName: string;
}
