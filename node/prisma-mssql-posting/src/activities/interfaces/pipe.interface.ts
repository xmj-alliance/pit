export interface IPipe<T> {
  input: unknown
  process: () => Promise<T>
}