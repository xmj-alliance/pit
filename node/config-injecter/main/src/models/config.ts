export interface AppConfig {
  [key: string]: any,
  // You need to define this interface yourself.
  your: string,
  own: string,
  app: string,
  config: string,
}

export interface IConfiguration {
  config: AppConfig,
}