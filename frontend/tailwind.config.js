/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{js,jsx,ts,tsx}', './index.html'],
  theme: {
    colors: {
      primary: {
        main: 'rgb(var(--color-primary-main) / <alpha-value>)',
        active: 'rgb(var(--color-primary-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-primary-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-primary-contrast) / <alpha-value>)'
      },
      secondary: {
        main: 'rgb(var(--color-secondary-main) / <alpha-value>)',
        active: 'rgb(var(--color-secondary-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-secondary-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-secondary-contrast) / <alpha-value>)'
      },
      error: {
        main: 'rgb(var(--color-error-main) / <alpha-value>)',
        active: 'rgb(var(--color-error-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-error-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-error-contrast) / <alpha-value>)'
      },
      warning: {
        main: 'rgb(var(--color-warning-main) / <alpha-value>)',
        active: 'rgb(var(--color-warning-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-warning-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-warning-contrast) / <alpha-value>)'
      },
      info: {
        main: 'rgb(var(--color-info-main) / <alpha-value>)',
        active: 'rgb(var(--color-info-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-info-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-info-contrast) / <alpha-value>)'
      },
      success: {
        main: 'rgb(var(--color-success-main) / <alpha-value>)',
        active: 'rgb(var(--color-success-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-success-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-success-contrast) / <alpha-value>)'
      },
      neutral: {
        main: 'rgb(var(--color-neutral-main) / <alpha-value>)',
        active: 'rgb(var(--color-neutral-active) / <alpha-value>)',
        disabled: 'rgb(var(--color-neutral-disabled) / <alpha-value>)',
        contrast: 'rgb(var(--color-neutral-contrast) / <alpha-value>)'
      },
      "action-disabled": 'var(--color-action-disabled)',
    },
    // textColor:{
    //   main: 'var(--color-text-main)',
    //   light: 'var(--color-text-light)',
    //   disabled: 'var(--color-text-disabled)',
    // }
  },
}