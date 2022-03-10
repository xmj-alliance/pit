const config = {
  // rootDir: ".",
  globals: {
    "ts-jest": {
      tsconfig: "tsconfig.json"
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
    "prisma/(.*)": ["<rootDir>/prisma/$1"],
    "src/(.*)": ["<rootDir>/src/$1"]
  }
}

module.exports = config;
