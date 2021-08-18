const { globals } = require('jest-preset-angular/jest-preset.js');

const config = {
  globals,
  preset: 'jest-preset-angular',
  testURL: 'https://github.com/just-jeb/angular-builders',
  // setupFilesAfterEnv: [`${__dirname}/setup.js`],
  moduleNameMapper: {
    "src/(.*)": ["<rootDir>/src/$1"],
    '\\.(jpg|jpeg|png)$': `${__dirname}/mock-module.js`,
  }
}

module.exports = config;
