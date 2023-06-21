/** @type {import('tailwindcss').Config} */
module.exports = {
    purge: {
        enabled: true,
        content: [
            './**/*.html',
            './**/*.razor'
        ],
    },
    content: [],
    theme: {
        screens: {
            sm: '640px',
            // => @media (min-width: 640px) { ... }

            md: '768px',
            // => @media (min-width: 768px) { ... }

            lg: '1024px',
            // => @media (min-width: 1024px) { ... }

            xl: '1280px',
            // => @media (min-width: 1280px) { ... }

            '2xl': '1536px',
            // => @media (min-width: 1536px) { ... }
        },
        extend: {
            screens: {
                'xs': '300px',
                // => @media (min-width: 992px) { ... }
            },
            colors: {
                'grey-900': '#1e1e1e',
                'grey-800': '#232323',
                'grey-700': '#282828',
                'grey-600': '#343434',
                'grey-500': '#393939',
                'grey-400': '#444444',
                'grey-300': '#4a4a4a',
                'grey-200': '#5a5a5a',
                'grey-100': '#2e2e2e',

                'text-grey-900': '#4a4a4a',
                'text-grey-800': '#616161',
                'text-grey-700': '#787878',
                'text-grey-600': '#8e8e8e',
                'text-grey-500': '#a5a5a5',
                'text-grey-400': '#bbbbbb',
                'text-grey-300': '#d2d2d2',
                'text-grey-200': '#e8e8e8',
                'text-grey-100': '#e8e8e8',

                
            },
        },
    },
    plugins: [],
}

