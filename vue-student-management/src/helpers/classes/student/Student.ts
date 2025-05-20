let idCounter = 1

export default class Student {
  id: number
  name: string
  email: string
  birthday: string
  gender: string

  constructor(name: string, email: string, birthday: string, gender: string) {
    this.id = idCounter++
    this.name = name
    this.email = email
    this.birthday = birthday
    this.gender = gender
  }
}
