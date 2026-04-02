"""Resize quest icon images from files/quest/to_resize/ to 314x177 and save to files/quest/icon/"""
from PIL import Image
import os

src = os.path.join(os.path.dirname(__file__), '..', 'files', 'quest', 'to_resize')
dst = os.path.join(os.path.dirname(__file__), '..', 'files', 'quest', 'icon')

os.makedirs(dst, exist_ok=True)

count = 0
for f in sorted(os.listdir(src)):
    if not f.lower().endswith('.png'):
        continue
    img = Image.open(os.path.join(src, f))
    img_resized = img.resize((314, 177), Image.LANCZOS)
    img_resized.save(os.path.join(dst, f))
    print(f'{f}: {img.size} -> 314x177')
    count += 1

print(f'\nDone: {count} images resized')
