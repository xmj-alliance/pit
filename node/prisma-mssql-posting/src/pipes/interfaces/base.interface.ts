export interface IPipe<T> {
  output: T | null
  task: Promise<T>
}