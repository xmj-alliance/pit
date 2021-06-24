const config = {
  // rootDir: ".",
  globals: {
    "ts-jest": {
      tsConfig: "./tsconfig.json"
    }
  },
  testEnvironment: "node",
  transform: {
    "^.+\\.ts?$": "ts-jest"
  },
  testMatch: [
    '**/*.test.ts'
  ],
  moduleFileExtensions: [
    "ts",
    "tsx",
    "js",
    "jsx",
    "json",
    "node"
  ],
  moduleNameMapper: {
    "src/(.*)": ["<rootDir>/src/$1"]
  }
}

module.exports = config;
