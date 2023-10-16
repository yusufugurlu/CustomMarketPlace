import React, { useState } from 'react';
import GlideGallery from 'components/carousel/GlideGallery';
import { Spinner } from 'react-bootstrap';

const CarouselGalleryBoxedWithLightbox = () => {
  const [photoIndex, setPhotoIndex] = useState(0);
  const [isOpen, setIsOpen] = useState(false);

  const openLightbox = (index) => {
    setPhotoIndex(index);
    setIsOpen(true);
  };
  const galleyItems = [
    {
      large: '/img/product/large/product-1.webp',
      thumb: '/img/product/small/product-1.webp',
    },
    {
      large: '/img/product/large/product-2.webp',
      thumb: '/img/product/small/product-2.webp',
    },
    {
      large: '/img/product/large/product-3.webp',
      thumb: '/img/product/small/product-3.webp',
    },
    {
      large: '/img/product/large/product-4.webp',
      thumb: '/img/product/small/product-4.webp',
    },
    {
      large: '/img/product/large/product-5.webp',
      thumb: '/img/product/small/product-5.webp',
    },
  ];

  return (
    <>
      <GlideGallery>
        <GlideGallery.LargeItems>
          {galleyItems.map((item, index) => (
            <GlideGallery.Item key={`boxed.large.${index}`}>
              <img alt="detail" src={item.large} className="responsive border-0 rounded-md img-fluid mb-3 w-100" onClick={() => openLightbox(index)} />
            </GlideGallery.Item>
          ))}
        </GlideGallery.LargeItems>
        <GlideGallery.ThumbItems>
          {galleyItems.map((item, index) => (
            <GlideGallery.Item key={`boxed.thumb.${index}`}>
              <img alt="thumb" src={item.thumb} className="responsive rounded-md img-fluid" />
            </GlideGallery.Item>
          ))}
        </GlideGallery.ThumbItems>
      </GlideGallery>
    </>
  );
};

export default CarouselGalleryBoxedWithLightbox;
