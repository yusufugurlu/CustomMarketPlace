import CsLineIcons from 'cs-line-icons/CsLineIcons';
import React, { useState } from 'react';
import { Button } from 'react-bootstrap'; // Örnek olarak React-Bootstrap kullanılıyor, siz kendi UI kit'inize uygun şekilde düzenleyebilirsiniz
import { CircularProgressbar } from 'react-circular-progressbar';


function CustomButton({ isLoading, onClick, text, iconName, size }) {
    return (
        <Button
            variant="quaternary"
            className="btn-icon btn-icon-start mb-1"
            onClick={onClick}
            disabled={isLoading}
            size= {size || 'small'}
        >
            {isLoading ?
                <>
                    <CircularProgressbar size={20} />
                </>
                :
                <>
                    <CsLineIcons icon={iconName} /> <span>{text}</span>
                </>
            }

        </Button>
    );
}

export default CustomButton;
