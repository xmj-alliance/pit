import { PrismaClient } from 'prisma/generated/prisma-client-js';

// add prisma to the NodeJS global
// Prevent multiple instances of Prisma Client in development
declare const global: any;

const prisma: PrismaClient = global.prisma || new PrismaClient();

if (process.env.NODE_ENV === 'development') global.prisma = prisma;

export default prisma;