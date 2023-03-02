import { createSignal } from "solid-js"

export default function ThemeSwitcher() {
    const [theme, setTheme] = createSignal("system" as "light" | "system" | "dark")

    const handleClick = () => {
        if (theme() === "light") {
            setTheme("system")
            return
        }

        if (theme() === "system") {
            setTheme("dark")
            return
        }

        if (theme() === "dark") {
            setTheme("light")
            return
        }
    }

    return <button class="flex items-center gap-3" onClick={handleClick}>
        <div class="relative p-2.5 sm:p-2 w-12 sm:w-9 border-2 border-neutral-main rounded-full">
            <div
                class="absolute rounded-full h-4 sm:h-3 w-4 sm:w-3 -m-2 sm:-m-1.5 bg-neutral-main transition-transform duration-150"
                classList={{
                    "translate-x-3 sm:translate-x-2": theme() === "system",
                    "translate-x-6 sm:translate-x-4": theme() === "dark"
                }}
            ></div>
        </div>
        <div class="sm:text-sm text-neutral-main w-14 sm:w-12 text-left select-none leading-none">
            {theme()}
        </div>
    </button>
}