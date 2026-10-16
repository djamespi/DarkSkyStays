// Original deterministic vector illustrations. Run with Node; no network or image libraries.
import { mkdirSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';

const output = fileURLToPath(new URL('../wwwroot/images/', import.meta.url));
mkdirSync(output, { recursive: true });
let seed = 42981;
const random = () => { seed = (seed * 1664525 + 1013904223) >>> 0; return seed / 4294967296; };
const stars = Array.from({ length: 470 }, () => {
  const x = (random() * 1600).toFixed(1), y = (random() * 645).toFixed(1);
  const r = (random() * 1.25 + .35).toFixed(2), opacity = (random() * .65 + .18).toFixed(2);
  return `<circle cx="${x}" cy="${y}" r="${r}" opacity="${opacity}"/>`;
}).join('');

const tree = (x, y, size, color = '#071318') => `<g transform="translate(${x} ${y}) scale(${size})" fill="${color}"><path d="M0 0 17 37 8 34 24 61 12 57 30 85 15 80 35 111 6 105 6 127h-12v-22l-29 6 20-31-15 5 18-28-12 4 16-27-9 3Z"/></g>`;

function cabin(x, y, scale = 1) {
  return `<g transform="translate(${x} ${y}) scale(${scale})"><ellipse cx="0" cy="55" rx="135" ry="33" fill="#e4a652" opacity=".12" filter="url(#soft)"/><path d="M-68 64 0-30 78 64Z" fill="#080e13" stroke="#9b7954" stroke-width="2"/><path d="M-49 59 1-9 55 59Z" fill="url(#window)"/><path d="M-49 59 1-9 55 59M1-9v68M-28 30h60M-41 47h84" fill="none" stroke="#342b24" stroke-width="3"/><path d="m-68 64-16-7L-9-44 0-30" fill="#142529"/><path d="m-84 57 75-101 18 1 81 105-12 2L0-30-68 64Z" fill="#1c2f33"/><path d="m-9-44 18 1 81 105" fill="none" stroke="#48616a" stroke-width="2"/><path d="M-79 68H90v8H-79Z" fill="#22342f"/><path d="M-74 78H85" stroke="#9f8b60" opacity=".6"/><path d="M-62 76v12M72 76v12" stroke="#172725" stroke-width="4"/><rect x="16" y="-28" width="10" height="22" fill="#1b292b"/><path d="M-34 57h19v-9h-19ZM15 54h18v5H15Z" fill="#c48641" opacity=".45"/></g>`;
}

function dome(x, y) {
  return `<g transform="translate(${x} ${y})"><ellipse cx="0" cy="76" rx="165" ry="38" fill="#d7994f" opacity=".16" filter="url(#soft)"/><path d="M-110 65a110 110 0 0 1 220 0Z" fill="url(#dome)" stroke="#ae9e82" stroke-width="2"/><path d="M-110 65 0-45 110 65M-78-10 78-10M-104 31 104 31M-78-10-45 65 0-45 45 65 78-10M-104 31-78-10 0 31 78-10 104 31M-45 65 0 31 45 65" stroke="#2a383a" stroke-width="2" fill="none" opacity=".8"/><path d="M-18 65V18a18 18 0 0 1 36 0v47Z" fill="#d7aa67" stroke="#354044" stroke-width="3"/><path d="M0 5v60" stroke="#81724d"/><path d="M-123 69h245v9h-245Z" fill="#30312c"/></g>`;
}

function tent(x, y) {
  return `<g transform="translate(${x} ${y})"><ellipse cx="0" cy="76" rx="155" ry="30" fill="#d7994f" opacity=".14" filter="url(#soft)"/><path d="M-119 65-22-42 34-34 119 65Z" fill="#78644e" stroke="#a99169" stroke-width="2"/><path d="M-119 65-22-42 65 65Z" fill="#b0956a"/><path d="M-80 65-22-23 28 65Z" fill="url(#window)"/><path d="M-80 65-22-23-33 65Z" fill="#d3b381"/><path d="m-22-23 50 88-34-8Z" fill="#b79c73"/><path d="M-22-42-22-55M-139 78-22-42 137 77" fill="none" stroke="#d2bc8b" stroke-width="2"/><path d="M-126 73h250" stroke="#514735" stroke-width="5"/><path d="M-141 76v10m279-10v10" stroke="#9c845a" stroke-width="3"/></g>`;
}

function landscape(style) {
  const desert = style === 'desert' || style === 'glamping', forest = style === 'forest' || style === 'fjord';
  const sky = desert ? ['#10182a', '#35445a', '#9b6c62'] : forest ? ['#071721', '#123c44', '#476b6b'] : ['#071323', '#173749', '#65858b'];
  const mountain = desert ? ['#555068', '#3c354b', '#292737', '#161c2a'] : forest ? ['#476265', '#24474b', '#17363c', '#0b232b'] : ['#405e73', '#2d4b62', '#1a384b', '#0e2837'];
  let reflection = '';
  for (let i = 0; i < 65; i++) {
    const y = 670 + i * 3.6, width = 15 + random() * 100 + i * 3, x = 1100 - width / 2 + random() * 50;
    reflection += `<path d="M${x.toFixed(1)} ${y.toFixed(1)}h${width.toFixed(1)}" stroke="${i < 20 ? '#b39a6d' : '#487180'}" opacity="${(.16 - i * .0015).toFixed(3)}" stroke-width="${(1 + random() * 2).toFixed(1)}"/>`;
  }
  let trees = '';
  if (!desert) {
    for (let i = 0; i < 43; i++) {
      const x = i < 22 ? i * 14 - 20 : 1360 + (i - 22) * 15;
      trees += tree(x, 580 + random() * 160, .45 + random() * 1.1, i % 3 ? '#081a23' : '#0d222b');
    }
    for (let i = 0; i < 12; i++) trees += tree(930 + i * 24, 610 + random() * 38, .22 + random() * .4, '#10272b');
  }
  return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1600 900" role="img" aria-label="Illustrated ${style === 'glamping' ? 'canvas tent in the desert' : style === 'fjord' ? 'dome by a northern fjord' : desert ? 'desert dome' : forest ? 'northern forest cabin' : 'alpine lakeside cabin'} under a starry sky">
  <defs>
    <linearGradient id="sky" x2="0" y2="1"><stop stop-color="${sky[0]}"/><stop offset=".6" stop-color="${sky[1]}"/><stop offset="1" stop-color="${sky[2]}"/></linearGradient>
    <linearGradient id="water" x2="0" y2="1"><stop stop-color="#294858"/><stop offset="1" stop-color="#081a26"/></linearGradient>
    <linearGradient id="milky"><stop stop-color="#8eabb5" stop-opacity="0"/><stop offset=".45" stop-color="#a6c0c4" stop-opacity=".3"/><stop offset="1" stop-color="#b2c7be" stop-opacity=".02"/></linearGradient>
    <linearGradient id="aurora" x2="0" y2="1"><stop stop-color="#69d8b5" stop-opacity="0"/><stop offset=".7" stop-color="#6ce0b4" stop-opacity=".3"/><stop offset="1" stop-color="#69d8b5" stop-opacity="0"/></linearGradient>
    <linearGradient id="window" x2="0" y2="1"><stop stop-color="#f3d194"/><stop offset="1" stop-color="#bc6f32"/></linearGradient>
    <radialGradient id="dome" cx=".5" cy=".85"><stop stop-color="#f5d08f"/><stop offset=".45" stop-color="#bc9a68"/><stop offset="1" stop-color="#4c6265"/></radialGradient>
    <radialGradient id="glow"><stop stop-color="#a8c3c5" stop-opacity=".25"/><stop offset="1" stop-color="#a8c3c5" stop-opacity="0"/></radialGradient>
    <filter id="blur"><feGaussianBlur stdDeviation="28"/></filter><filter id="soft"><feGaussianBlur stdDeviation="12"/></filter>
    <filter id="grain"><feTurbulence type="fractalNoise" baseFrequency=".7" numOctaves="3" stitchTiles="stitch"/><feColorMatrix type="saturate" values="0"/><feComponentTransfer><feFuncA type="linear" slope=".09"/></feComponentTransfer><feBlend in="SourceGraphic" mode="soft-light"/></filter>
  </defs>
  <rect width="1600" height="900" fill="url(#sky)"/>
  <ellipse cx="1080" cy="420" rx="580" ry="380" fill="url(#glow)"/>
  <path d="M700-140C850 60 1020 160 1230 330S1430 420 1520 570" fill="none" stroke="url(#milky)" stroke-width="145" filter="url(#blur)"/>
  <path d="M760-120C900 70 1090 230 1220 310S1370 450 1430 500" fill="none" stroke="#93b2b7" stroke-opacity=".075" stroke-width="35" filter="url(#soft)"/>
  ${forest ? '<path d="M450-80C630 350 900 45 1180 80s230 280 470 200" fill="none" stroke="url(#aurora)" stroke-width="190" filter="url(#blur)"/><path d="M560-50C680 260 900 80 1120 120s300 220 490 180" fill="none" stroke="#8ae5b0" stroke-opacity=".16" stroke-width="7" filter="url(#soft)"/>' : ''}
  <g fill="#e1e9dd">${stars}</g>
  <g stroke="#e1e9d4" stroke-width=".9" opacity=".8"><path d="M1215 105v12m-6-6h12M950 207v8m-4-4h8M1480 166v10m-5-5h10M635 185v8m-4-4h8"/></g>
  ${desert ? '<path d="M1320 125a26 26 0 1 0 32 35 30 30 0 0 1-32-35Z" fill="#e1debf"/>' : ''}
  <path d="M0 575 75 530 160 555 280 430 315 450 360 411 410 485 460 430 525 470 620 360 670 415 740 320 770 347 811 283 865 365 900 350 970 438 1030 372 1080 410 1135 350 1165 390 1210 370 1280 452 1340 393 1450 480 1520 445 1600 500V900H0Z" fill="${mountain[0]}"/>
  ${!desert ? '<g fill="#adc2c4" opacity=".47"><path d="m740 320-52 98 70-59 30 21-18-33ZM811 283l-31 60 29-15 12 20 19-4 25 21ZM620 360l-28 59 31-29 24 17ZM1135 350l-40 69 42-38 26 12Z"/></g>' : ''}
  <g fill="${mountain[1]}"><path d="M0 590 96 535 185 556 255 483 330 540 375 509 440 574 510 550 580 605 650 570 710 595 775 520 825 546 900 471 980 565 1040 525 1100 573 1180 495 1225 546 1290 507 1350 570 1430 523 1510 570 1600 520V900H0Z"/></g>
  <g fill="none" stroke="#718d99" stroke-width="1" opacity=".13"><path d="m811 283-35 160-76 125m112-238 32 66-8 58m64-103-44 86 34 30m-268-107-13 102-70 90m654-201-16 99 71 78"/></g>
  <path d="M0 645 100 580 195 604 266 574 340 619 422 600 519 662 615 638 690 675 785 637 860 648 970 605 1020 623 1100 593 1180 634 1260 607 1350 642 1450 590 1510 612 1600 580V900H0Z" fill="${mountain[2]}"/>
  ${!desert ? '<path d="M380 705Q800 642 1215 680L1550 900H190Z" fill="url(#water)"/>' : '<path d="M0 710Q270 630 615 720T1600 690V900H0Z" fill="#51424a"/>'}
  <path d="M0 700Q210 665 455 706T825 694Q1020 648 1220 681T1600 645V900H1585Q1370 783 1145 755T640 803Q350 756 0 850Z" fill="${mountain[3]}"/>
  ${!desert ? reflection : '<path d="M0 825Q360 710 720 814T1600 770V900H0Z" fill="#242635"/>'}
  <ellipse cx="1120" cy="708" rx="190" ry="40" fill="#d6a259" opacity=".1" filter="url(#soft)"/>
  ${style === 'glamping' ? tent(1115, 620) : desert || style === 'fjord' ? dome(1115, 620) : cabin(1150, 625, forest ? 1.25 : 1.05)}
  ${trees}
  <path d="M0 849Q120 788 300 844T630 864L690 900H0ZM1380 830Q1500 793 1600 809V900h-270Z" fill="#06131b"/>
  <g opacity=".4" fill="#34505a"><ellipse cx="905" cy="790" rx="12" ry="3"/><ellipse cx="823" cy="840" rx="24" ry="4"/><ellipse cx="690" cy="810" rx="15" ry="2"/></g>
  <rect width="1600" height="900" filter="url(#grain)" opacity=".24"/>
  </svg>`;
}

const save = (name, content) => writeFileSync(`${output}${name}`, content.replace(/[\t ]+$/gm, ''));
const alpine = landscape('alpine');
save('night-landscape.svg', alpine);
save('stay-alpine.svg', alpine);
save('stay-desert.svg', landscape('desert'));
save('stay-forest.svg', landscape('forest'));
save('stay-fjord.svg', landscape('fjord'));
save('stay-camp.svg', landscape('glamping'));
console.log('Created six local night-sky illustrations.');
