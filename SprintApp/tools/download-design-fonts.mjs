import { mkdir, writeFile } from 'node:fs/promises';

const destination = new URL('../wwwroot/fonts/', import.meta.url);
await mkdir(destination, { recursive: true });
const files = [
  ['fraunces/Fraunces%5BSOFT%2CWONK%2Copsz%2Cwght%5D.ttf', 'Fraunces-Variable.ttf'],
  ['fraunces/Fraunces-Italic%5BSOFT%2CWONK%2Copsz%2Cwght%5D.ttf', 'Fraunces-Italic-Variable.ttf'],
  ['spacegrotesk/SpaceGrotesk%5Bwght%5D.ttf', 'SpaceGrotesk-Variable.ttf'],
  ['fraunces/OFL.txt', 'Fraunces-OFL.txt'],
  ['spacegrotesk/OFL.txt', 'SpaceGrotesk-OFL.txt'],
];
for (const [source, name] of files) {
  const response = await fetch(`https://raw.githubusercontent.com/google/fonts/main/ofl/${source}`);
  if (!response.ok) throw new Error(`${name}: HTTP ${response.status}`);
  const data = Buffer.from(await response.arrayBuffer());
  await writeFile(new URL(name, destination), name.endsWith('.txt') ? data.toString('utf8').replace(/[ \t]+$/gm, '') : data);
  console.log(`Downloaded ${name}`);
}
