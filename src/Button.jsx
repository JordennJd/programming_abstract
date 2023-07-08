import React from 'react';
import PropTypes from 'prop-types';


const Button = ({
                    children, onClick, disabled, active, ...attrs
                }) => {
    const onClickAction = e => {
        if (disabled) {
            e.preventDefault();
        } else {
            return onClick(e);
        }
    };
    

    const Tag = attrs.href ? 'a' : 'button';

    return (
        <Tag
            disabled={disabled}
            onClick={onClickAction}
            {...attrs}
        >
            {children}
        </Tag>
    );
};

Button.propTypes = {
    children: PropTypes.node,
    onClick: PropTypes.func,
    disabled: PropTypes.bool,
    active: PropTypes.bool,
};

Button.defaultProps = {
    children: 'Default button',
    onClick: () => {},
    disabled: false,
    active: false,
};

export default Button;