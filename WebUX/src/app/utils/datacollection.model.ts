export class DataCollection {
  constructor(dto: any = null) {
    if (dto != null) {
      Object.assign(this, dto);
    }
  }

  id: string = '';
  deviceId: string = '';
  status: string = '';
  when: Date = new Date()
}
