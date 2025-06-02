FROM oven/bun:alpine

WORKDIR /app

COPY package.json .
COPY bun.lock .

RUN bun install

EXPOSE 3000

COPY . .

CMD ["bun", "run", "dev"]